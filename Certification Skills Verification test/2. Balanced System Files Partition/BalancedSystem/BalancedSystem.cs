using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

	/*
     * Complete the 'mostBalancedPartition' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY parent
     *  2. INTEGER_ARRAY files_size
     */

	public static int mostBalancedPartition(List<int> parent, List<int> files_size)
	{
		int n = parent.Count;
		Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
		for (int i = 0; i < n; i++)
		{
			if (!adjList.ContainsKey(parent[i]))
			{
				adjList[parent[i]] = new List<int>();
			}
			adjList[parent[i]].Add(i);
		}
		int totalSize = 0;
		foreach (int size in files_size)
		{
			totalSize += size;
		}
		int[] subtreeSizes = new int[n];
		CalculateSubtreeSizes(0, adjList, files_size, subtreeSizes);

		int minAbsoluteDifference = int.MaxValue;
		for (int i = 1; i < n; i++)
		{
			int subtree1Size = subtreeSizes[i];
			int subtree2Size = totalSize - subtree1Size;
			int absoluteDifference = Math.Abs(subtree1Size - subtree2Size);

			minAbsoluteDifference = Math.Min(minAbsoluteDifference, absoluteDifference);
		}

		return minAbsoluteDifference;

	}
	private static int CalculateSubtreeSizes(int node, Dictionary<int, List<int>> adjList, List<int> files_size, int[] subtreeSizes)
	{
		int size = files_size[node];

		if (adjList.ContainsKey(node))
		{
			foreach (int child in adjList[node])
			{
				size += CalculateSubtreeSizes(child, adjList, files_size, subtreeSizes);
			}
		}

		subtreeSizes[node] = size;
		return size;
	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int parentCount = Convert.ToInt32(Console.ReadLine().Trim());

		List<int> parent = new List<int>();

		for (int i = 0; i < parentCount; i++)
		{
			int parentItem = Convert.ToInt32(Console.ReadLine().Trim());
			parent.Add(parentItem);
		}

		int files_sizeCount = Convert.ToInt32(Console.ReadLine().Trim());

		List<int> files_size = new List<int>();

		for (int i = 0; i < files_sizeCount; i++)
		{
			int files_sizeItem = Convert.ToInt32(Console.ReadLine().Trim());
			files_size.Add(files_sizeItem);
		}

		int result = Result.mostBalancedPartition(parent, files_size);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}

