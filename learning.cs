using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Learning{
	class TextParser{
		public static StringBuilder sb = new StringBuilder();
		static void Main(string[] args){
			Take_input();
			string[] text = Jumble_letters(Parse(sb.ToString()));
			string result = string.Concat(text);
			Console.WriteLine(result);
		}
		private static string[] Parse(string input){
			char[] delimiters = {' ','-'};
			string[] text = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
			return text;
		}
		private static void Take_input(){
			while (true){
				string line = Console.ReadLine();
				if(line.ToLower() == "end"){
					break;
				}
				sb.AppendLine(line);
			}
		}
		private static string[] Jumble_letters(string[] parsed_text){
			List<string> jumbled_text = new List<string>();
			foreach(string word in parsed_text){
				char[] letters = word.ToCharArray();
				string newWord = new string(letters.OrderBy( l => Guid.NewGuid()).ToArray()) + " ";
				jumbled_text.Add(newWord);
			}
			return jumbled_text.ToArray();	
		}
	}
}
