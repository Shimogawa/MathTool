using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathTool.Tool.Utils;

namespace MathTool.Tool.Algebra.Groups
{
	public class Permutation : ICloneable, IEquatable<Permutation>
	{
		private Dictionary<int, int> function;

		public IntRange Range { get; private set; }

		private Permutation()
		{
			function = new Dictionary<int, int>();
		}

		public Permutation(params int[] numbers)
		{
			function = new Dictionary<int, int>();
			int max = numbers.Max();
			int min = numbers.Min();
			Range = new IntRange(min, max);
			for (int i = min; i <= max; i++)
			{
				try
				{
					bool added = false;
					for (int j = 0; j < numbers.Length; j++)
					{
						if (numbers[j] == i)
						{
							function.Add(numbers[j], numbers[(j + 1) % numbers.Length]);
							added = true;
							break;
						}
					}

					if (!added)
					{
						function.Add(i, i);
					}
				}
				catch (ArgumentException)
				{
					throw new ArgumentException("Not a valid permutation.");
				}
			}
		}

		public Permutation(int min, int max)
		{
			if (max < min) 
				throw new ArgumentException("Negative length.");
			Range = new IntRange(min, max);
			function = new Dictionary<int, int>();
			for (int i = min; i < max; i++)
			{
				function.Add(i, i + 1);
			}
			function.Add(max, min);
		}

		public Permutation(int length) : this(1, length)
		{
		}

		public int this[int i] => function[i];

		public static Permutation operator *(Permutation c1, Permutation c2)
		{
			return Multiply(c1, c2);
		}

		public static Permutation operator ^(Permutation c, int n)
		{
			var v = new Permutation();
			v.Range = c.Range.Clone() as IntRange;
			for (int i = c.Range.Min; i <= c.Range.Max; i++)
			{
				int num = i;
				for (int j = 0; j < n; j++)
				{
					num = c[num];
				}

				v.function.Add(i, num);
			}

			for (int i = c.Range.Min; i <= c.Range.Max; i++)
			{
				if (!v.function.ContainsKey(i))
				{
					v.function.Add(i, i);
				}
			}

			return v;
		}

		public static bool IsIdentity(Permutation permutation)
		{
			foreach (var key in permutation.function.Keys)
			{
				if (permutation[key] != key)
				{
					return false;
				}
			}

			return true;
		}

		public override string ToString()
		{
//			if (IsIdentity(this))
//			{
//				return "id";
//			}
			var sb = new StringBuilder();
			var isolates = new StringBuilder();
			bool[] used = new bool[function.Count];
			
			int start = Range.Min;
			int next = function[start];
			int num = 0;

			foreach (var k in function.Keys)
			{
				if (function[k] == k)
				{
					used[k - Range.Min] = true;
					num++;
					isolates.Append($"({k})");
				}
			}

			while (num != used.Length)
			{
				start = Range.Min;
				while (used[start - Range.Min])
				{
					start++;
					next = function[start];
				}
				sb.Append('(');
				sb.Append(start);
				sb.Append(' ');
				num++;
				used[start - Range.Min] = true;

				while (next != start)
				{
					sb.Append(next);
					used[next - Range.Min] = true;
					sb.Append(' ');
					next = function[next];
					num++;
				}

				sb.Remove(sb.Length - 1, 1);
				sb.Append(')');
			}

			sb.Append(isolates);
			return sb.ToString();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Permutation))
			{
				return false;
			}

			var o = (Permutation) obj;

			return Equals(o);
		}

		public bool Equals(Permutation other)
		{
			if (other == null) return false;
			if (!other.Range.Equals(Range)) return false;
			for (int i = Range.Min; i <= Range.Max; i++)
			{
				if (this[i] != other[i])
					return false;
			}

			return true;
		}

		public void ExtendTo(int min, int max)
		{
			IntRange intRange = new IntRange(min, max);
			if (!intRange.IsSubrange(Range))
				throw new Exception("Cannot extend to a smaller range.");
			for (int i = min; i <= max; i++)
			{
				if (!function.ContainsKey(i))
				{
					function.Add(i, i);
				}
			}

			Range = intRange;
		}

		public void ExtendTo(IntRange range)
		{
			ExtendTo(range.Min, range.Max);
		}

		public static Permutation Identity(int min, int max)
		{
			var r = new Permutation();
			for (int i = min; i < max; i++)
			{
				r.function.Add(i, i);
			}

			return r;
		}

		public static Permutation Multiply(Permutation c1, Permutation c2)
		{
			Permutation c = new Permutation();
			Permutation left = (Permutation)c1.Clone();
			Permutation right = (Permutation)c2.Clone();

			IntRange range = IntRange.RangeMinMax(left.Range, right.Range);
			c.Range = range;
			left.ExtendTo(range);
			right.ExtendTo(range);

			for (int i = range.Min; i <= range.Max; i++)
			{
				int num = left[right[i]];
				c.function.Add(i, num);
			}

			return c;
		}

		public static Permutation Parse(string str)
		{
			if (!str.StartsWith("(") && !str.EndsWith(")"))
				throw new ArgumentException("Not a valid permutation.");
			var ss = str.Split(new [] {"("}, StringSplitOptions.RemoveEmptyEntries);
			List<Permutation> perms = new List<Permutation>();
			foreach (var s in ss)
			{
				string j = s.Substring(0, s.Length - 1);
				if (j.Contains(" "))
				{
					string[] jj = j.Split(' ');
					List<int> nums = new List<int>();
					foreach (var ii in jj)
					{
						if (!int.TryParse(ii, out int iii)) 
							throw new ArgumentException("Not a valid permutation.");
						nums.Add(iii);
					}
					perms.Add(new Permutation(nums.ToArray()));
					continue;
				}

				int[] nm = new int[j.Length];
				for (int i = 0; i < j.Length; i++)
				{
					int num = j[i] - '0';
					if (num < 0 || num >= 10)
						throw new ArgumentException("Not a valid permutation.");
					nm[i] = num;
				}
				perms.Add(new Permutation(nm));
			}

			Permutation result = perms[perms.Count - 1];
			for (int i = perms.Count - 2; i >= 0; i++)
			{
				result = perms[i] * result;
			}

			return result;
		}

		public object Clone()
		{
			Permutation c = new Permutation();
			c.function = function.ToDictionary(e => e.Key, e => e.Value);	// stupid way to copy a dictionary
			c.Range = Range.Clone() as IntRange;
			return c;
		}
	}
}
