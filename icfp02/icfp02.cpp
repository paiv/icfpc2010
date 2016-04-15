#include <iostream>
#include <vector>
#include <string>
#include <stdio.h>

using namespace std;

struct Link{
    int gate;
    enum Place {Left,Right} place;
    Link(){}
    Link(int gate, Place place)
     : gate(gate), place(place) {}
    Link(int gate, char place)
     : gate(gate), place((place=='r' || place=='R') ? Place::Right : Place::Left) {}
};

struct Gate{
    int inValues[2];
    int outValues[2];
    Link inL;
    Link inR;
    Link outL;
    Link outR;
};

char readStringDelimitedBy(char * delims, string & dest)
{
    static string stringAccu;
    string inString;
    char ret;

    while (!cin.eof())
    {
        cin >> inString;
        stringAccu += inString;
        if (delims[0])
        {
            size_t delimPos = stringAccu.find_first_of(delims);
            if (delimPos == string::npos)
                continue;
            dest = stringAccu.substr(0, delimPos);
            ret = stringAccu[delimPos];
            stringAccu = stringAccu.substr(delimPos+1);
            return ret;
        }
        else
        {
            dest = stringAccu;
            stringAccu.clear();
            return '\n';
        }
    }
    return 0;
}

bool readLink(const char * & str, Link & link)
{
    if (str[0]=='X')
    {
        link.gate = -1;
        ++str;
    }
    else
    {
        int nread;
        int nGate;
        char place;
        if (sscanf(str, "%d%c%n", &nGate, &place, &nread)<2)
            return false;
        link = Link(nGate, place);
        str += nread;
    }
    return true;
}

bool readLinks(const char * str, Link & linkL, Link & linkR)
{
    if (!readLink(str, linkL))
        return false;
    if (!readLink(str, linkR))
        return false;
    return true;
}

bool readFactory(vector <Gate> & factory, Link & extIn, Link & extOut)
{
    string inputToken;
    int gateNum;
    char placeDef;

    if (!readStringDelimitedBy(":", inputToken))
        return false;
    sscanf(inputToken.c_str(), "%d%c", &gateNum, &placeDef);
    extIn = Link(gateNum, placeDef);

    char delim;
    while (delim = readStringDelimitedBy(",:", inputToken))
    {
        size_t sepPos = inputToken.find("0#");
        if (sepPos == string::npos)
            return false;
        inputToken[sepPos] = '\0';
        Gate gate;
        Link linkL, linkR;
        if (!readLinks(inputToken.c_str(), linkL, linkR))
            return false;
        gate.inL = linkL;
        gate.inR = linkR;
        if (!readLinks(inputToken.c_str()+sepPos+2, linkL, linkR))
            return false;
        gate.outL = linkL;
        gate.outR = linkR;
        gate.inValues[Link::Left] = 0;
        gate.inValues[Link::Right] = 0;
        gate.outValues[Link::Left] = 0;
        gate.outValues[Link::Right] = 0;
        factory.push_back(gate);
        if (delim == ':')
            break;
    }
    if (!delim)
        return false;
    if (!readStringDelimitedBy("", inputToken))
        return false;
    sscanf(inputToken.c_str(), "%d%c", &gateNum, &placeDef);
    extOut = Link(gateNum, placeDef);
    return true;
}

static const int RTable[3][3] = {
    { 2, 2, 2 },
    { 2, 0, 1 },
    { 2, 1, 0 }
};

void computeGate(Gate & gate)
{
    gate.outValues[Link::Left]
     = (3 + gate.inValues[Link::Left] - gate.inValues[Link::Right])%3;
    gate.outValues[Link::Right]
     = RTable[gate.inValues[Link::Left]][gate.inValues[Link::Right]];
}

int iterateFactory(vector <Gate> & factory, Link & extIn, Link & extOut, int inVal)
{
    factory[extIn.gate].inValues[extIn.place] = inVal;

    for (vector <Gate>::iterator i = factory.begin(); i!=factory.end(); ++i)
    {
        // Load inputs
        if (i->inL.gate >= 0)
            i->inValues[Link::Left] = factory[i->inL.gate].outValues[i->inL.place];
        if (i->inR.gate >= 0)
            i->inValues[Link::Right] = factory[i->inR.gate].outValues[i->inR.place];
        // Compute outputs
        computeGate(*i);
    }
    return factory[extOut.gate].outValues[extOut.place];
}

int main ()
{
    Link extIn, extOut;
    vector <Gate> factory;

    if (!readFactory(factory, extIn, extOut))
        return 1;

    char c;
    string outS;
    while (true)
    {
        cin >> c;
        if (!cin.good())
            break;
        if (c<'0' || c>'2')
            continue;
        int outVal = iterateFactory(factory, extIn, extOut, c-'0');
        outS += (char)('0'+outVal);
    }

    cout << outS;

    return 0;
}
