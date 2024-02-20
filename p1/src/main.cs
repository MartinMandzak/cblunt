
using System;

namespace cblunt.p1.src.GameOfLife {
		public class Board {
			private int[,] squares;
		
			//constructor
			public Board(int rows, int cols){
				squares = new int[rows,cols];
			}
			
			public void Write(){
				for(int i = 0; i<squares.GetLength(0); i++){
					for(int j = 0; j <squares.GetLength(1);j++){
						Console.Write(squares[i,j].ToString() + " ");
					}
					Console.WriteLine();
				}
			}
		}

		public class ActiveBoard : Board{
			public ActiveBoard(int rows, int cols) : base(rows,cols){}

			public void Blank(){
				Console.WriteLine("xd");
			}	
		}

		public class App{
			public static void Main(string[] args){
				var testBoard = new ActiveBoard(10,10);
				testBoard.Write();
			}
		}
}
