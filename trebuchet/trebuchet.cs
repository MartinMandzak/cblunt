/* https://adventofcode.com/2023/day/1 */

//IMPORTS
using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.IO;

namespace DayOne{

	public enum NumValues{
		zero = 0,
		one = 1,
		two = 2,
		three = 3,
		four = 4,
		five = 5,
		six = 6,
		seven = 7,
		eight = 8,
		nine = 9
	}

	class Trebuchet{
		static void Main(string[] args){
			ArrayList parsed_input = Take_input();
			Console.WriteLine(parsed_input.Cast<int>().Sum());
		}
		private static ArrayList Take_input(){
			//NumValues numvals;
			ArrayList result = new ArrayList();
			
			try {
				using (StreamReader  sr = new StreamReader("./trebuchet_input.txt")){	

					string line;
					while((line = sr.ReadLine()) != null){
						string first="a"; string last="z";
						result.Add(int.Parse(first+last));
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
