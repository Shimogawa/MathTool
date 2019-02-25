using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathTool.Tool.Algebra.Groups;

namespace MathToolTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Permutation sigma = Permutation.Parse("(12)");
			Permutation tau = Permutation.Parse("(12345)");

			for (int i = 1; i < 6; i++)
			{
				Console.WriteLine($"(1 2 3 4 5) ^ {i} = {tau ^ i}");
			}

			for (int i = 1; i <= 5; i++)
			{
				Console.WriteLine($"(1 2) * (1 2 3 4 5) ^ {i} = {sigma * (tau ^ i)}");
			}

			for (int i = 1; i <= 5; i++)
			{
				for (int j = 1; j < 6; j++)
				{
					Console.WriteLine($"(1 2 3 4 5) ^ {j}  * (1 2) * (1 2 3 4 5) ^ {i} = {(tau ^ j) * sigma * (tau ^ i)}");
				}
			}

			Console.ReadLine();
		}
	}
}
