using cblunt.trebuchet.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cblunt.trebuchet.MyTokenizer{
	public class PrecedenceTokenizer : ITokenizer{
		private List<TokenDefinition> _tokenDefinitions;
		
		public PrecedenceTokenizer(){
			_tokenDefinitions = new List<TokenDefinition>();

			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^zero$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^one$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^two$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^three$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^four$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^five$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^six$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^seven$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^eight$",1));
			_tokenDefinitions.Add(new TokenDefinition(TokenType.zero, "^nine$",1));
		}

		public IEnumerable<Token> Tokenize(string text){
			var tokenMatches = FindTokenMatches(text);

			var groupedByIndex = tokenMatches.GroupBy(x => x.StartIndex)
																			 .OrderBy(x => x.Key)
																			 .ToList();
			TokenMatch lastMatch = null;
			for(int i = 0; i<groupedByIndex.Count;i++){
				var bestMatch = groupedByIndex[i].OrderBy(x=>x.Precedence).First();
				if(lastMatch != null && bestMatch.StartIndex < lastMatch.EndIndex)
					continue;
				yield return new Token(bestMatch.TokenType, bestMatch.Value);
				lastMatch = bestMatch;
			}
			yield return new Token(TokenType.SequenceTerminator);
		}
		private List<TokenMatch> FindTokenMatches(string text){
			var tokenMatches = new List<TokenMatch>();
			foreach(var tokenDef in _tokenDefinitions){
				tokenMatches.addRange(tokenDef.FindMatches(text).ToList());
			}
			return tokenMatches;
		}
	}
}
