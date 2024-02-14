/* https://adventofcode.com/2023/day/1 */

//IMPORTS
using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.IO;

namespace DayOne{
	class Trebuchet{
		static void Main(string[] args){
			ArrayList parsed_input = Take_input();
			Console.WriteLine(parsed_input.Cast<int>().Sum());
		}
		private static ArrayList Take_input(){
			char[] numbers = {'0','1','2','3','4','5','6','7','8','9'};
			ArrayList result = new ArrayList();
			
			try {
				using (StreamReader  sr = new StreamReader("./trebuchet_input.txt")){	

					string line;
					while((line = sr.ReadLine()) != null){
						Console.WriteLine(line);
						char first='a'; char last='z';
						for(int idx = 0; idx < line.Length / 2; idx ++){
							if(first == 'a' && Array.IndexOf(numbers, line[idx]) != -1){
								first = line[idx];
							}
							if(last == 'z' && Array.IndexOf(numbers, line[line.Length - idx - 1])!=-1){
								last = line[line.Length - idx - 1];
							}
						}
						result.Add(int.Parse(first.ToString() + last.ToString()));
					}
					return result;
				}
			}
			catch (IOException e){
				Console.WriteLine(e.Message);
				return result;
			}
		}
	}
}
