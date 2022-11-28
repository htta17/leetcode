<details>
  <summary>https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/description/
  </summary>
  
  You are given an array of strings words. Each element of words consists of two lowercase English letters.

Create the longest possible palindrome by selecting some elements from words and concatenating them in any order. Each element can be selected at most once.

Return the length of the longest palindrome that you can create. If it is impossible to create any palindrome, return 0.

A palindrome is a string that reads the same forward and backward.
  
  ```cs
  public int LongestPalindrome(string[] words) {
      //dictionary to store: 
      //  - Item1: This word can be in middle or not. Same character can be in middle, ex: 'aa', 'bb'. 'ab' or 'yz' cannot. 
      //  - Item2: The frequence of a word
      //  - Item3: The frequence of a REVERSED word
      //If a dic["te"] has value like (false, 3, 4) means 'te' appeared 3 times, and 'et' appeared 4 times
      //We can use 'tetete' and 'etetet' 
      var dic = new Dictionary<string, (bool, int, int)>();
      foreach(var word in words) {
          if (word[0] == word[1]) { //Can put anywhere
              dic[word] = (true, dic.ContainsKey(word) ? dic[word].Item2 + 1 : 1, 0);
          }
          else {
              var reverse = word[1].ToString() + word[0].ToString();
              if (dic.ContainsKey(word)) {
                  dic[word] = (false, dic[word].Item2 + 1, dic[word].Item3);
              }
              else if (dic.ContainsKey(reverse)) {
                  dic[reverse] = (false, dic[reverse].Item2 , dic[reverse].Item3 + 1);
              }
              else {
                  dic[word] = (false,1, 0);
              }
          }
      } 

      var pairs = 0;
      var middle = 0; 
      foreach(var item in dic) {
          if (item.Value.Item1) {
              if (item.Value.Item2 % 2 == 0) {
                  pairs += item.Value.Item2; //Use all 
              }
              else {
                  pairs += item.Value.Item2 - 1;// If 'aa' appear 5 times --> Use 4 pairs and middle
                  middle = 1;
              }
          } else {
              var min = Math.Min(item.Value.Item2, item.Value.Item3);
              pairs += min * 2;
          }
      }

      return (pairs + middle) * 2;

  }
  ```


</details>