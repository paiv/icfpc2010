
using System;
namespace icfp03
{
	/// <summary>
	/// http://msdn.microsoft.com/en-us/library/ff650211.aspx
	/// </summary>
	public class Permutation
	{
		private int[] data = null;
		private int order = 0;

		public Permutation(int n)
		{
			this.data = new int[n];
			for(int i = 0; i < n; ++i)
			{
				this.data[i] = i;
			}

			this.order = n;
		}

		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("( ");
			for(int i = 0; i < this.order; ++i)
			{
				sb.Append(this.data[i].ToString() + " ");
			}
			sb.Append(")");

			return sb.ToString();
		}  // ToString()

		// other methods
		public Permutation(int[] a)
		{
			this.data = (int[])a.Clone();
			//this.data = new int[a.Length];
			//a.CopyTo(this.data, 0);
			this.order = a.Length;
		}

		public bool IsValid()
		{
			if(this.data.Length != this.order)
				return false;

			bool[] checks = new bool[this.data.Length];

			for(int i = 0; i < this.order; ++i)
			{
				if(this.data[i] < 0 || this.data[i] >= this.order)
					return false;  // value out of range

				if(checks[this.data[i]] == true)
					return false;  // duplicate value

				checks[this.data[i]] = true;
			}

			return true;
		}  // IsValid()

		public Permutation(int n, int k)
		{
			this.data = new int[n];
			this.order = this.data.Length;

			// Step #1 - Find factoradic of k
			int[] factoradic = new int[n];

			for(int j = 1; j <= n; ++j)
			{
				factoradic[n - j] = k % j;
				k /= j;
			}

			// Step #2 - Convert factoradic to permuatation
			int[] temp = new int[n];

			for(int i = 0; i < n; ++i)
			{
				temp[i] = ++factoradic[i];
			}

			this.data[n - 1] = 1;  // right-most element is set to 1.

			for(int i = n - 2; i >= 0; --i)
			{
				this.data[i] = temp[i];
				for(int j = i + 1; j < n; ++j)
				{
					if(this.data[j] >= this.data[i])
						++this.data[j];
				}
			}

			for(int i = 0; i < n; ++i)  // put in 0-based form
			{
				--this.data[i];
			}

		}  // Permutation(n,k)

		public Permutation Successor()
		{
			Permutation result = new Permutation(this.order);

			int left, right;

			for(int k = 0; k < result.order; ++k)  // Step #0 - copy current data into result
			{
				result.data[k] = this.data[k];
			}

			left = result.order - 2;  // Step #1 - Find left value 
			while((result.data[left] > result.data[left + 1]) && (left >= 1))
			{
				--left;
			}
			if((left == 0) && (this.data[left] > this.data[left + 1]))
				return null;

			right = result.order - 1;  // Step #2 - find right; first value > left
			while(result.data[left] > result.data[right])
			{
				--right;
			}

			int temp = result.data[left];  // Step #3 - swap [left] and [right]
			result.data[left] = result.data[right];
			result.data[right] = temp;


			int i = left + 1;              // Step #4 - order the tail
			int j = result.order - 1;

			while(i < j)
			{
				temp = result.data[i];
				result.data[i++] = result.data[j];
				result.data[j--] = temp;
			}

			return result;
		}  // Successor()
		public T[] ApplyTo<T>(T[] arr)
		{
			if(arr.Length != this.order)
				return null;

			T[] result = new T[arr.Length];
			for(int i = 0; i < result.Length; ++i)
			{
				result[i] = arr[this.data[i]];
			}

			return result;
		}  // ApplyTo()

		public int[] Get()
		{
			//return (int[])data.Clone();
			return data;
		}

		public Permutation Inverse()
		{
			int[] inverse = new int[this.order];

			for(int i = 0; i < inverse.Length; ++i)
			{
				inverse[this.data[i]] = i;
			}

			return new Permutation(inverse);
		}  // Inverse()

	}  // class Permutation 
}
