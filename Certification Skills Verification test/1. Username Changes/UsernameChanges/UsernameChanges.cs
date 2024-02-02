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
     * Complete the 'possibleChanges' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY usernames as parameter.
     */

	public static List<string> possibleChanges(List<string> usernames)
	{
		List<string> results = new List<string>();
		foreach (string username in usernames)
		{
			results.Add(CanChangeUsername(username));
		}
		return results;
	}
	public static string CanChangeUsername(string username)
	{
		for (int i = 0; i < username.Length - 1; i++)
		{
			for (int j = i + 1; j < username.Length; j++)
			{
				if (username[i] > username[j])
				{
					// Swap the characters at positions i and j
					char[] usernameArray = username.ToCharArray();
					char temp = usernameArray[i];
					usernameArray[i] = usernameArray[j];
					usernameArray[j] = temp;
					string modifiedUsername = new string(usernameArray);
					// Check if modified username is smaller
					if (String.Compare(modifiedUsername, username) < 0)
					{
						return "YES";
					}
					else
					{
						return "NO";
					}
				}
			}
		}
		return "NO";
	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int usernamesCount = Convert.ToInt32(Console.ReadLine().Trim());

		List<string> usernames = new List<string>();

		for (int i = 0; i < usernamesCount; i++)
		{
			string usernamesItem = Console.ReadLine();
			usernames.Add(usernamesItem);
		}

		List<string> result = Result.possibleChanges(usernames);

		textWriter.WriteLine(String.Join("\n", result));

		textWriter.Flush();
		textWriter.Close();
	}
}