
using System.Data;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;


Solution sol = new Solution();
sol.CharacterReplacement("BAAA", 0);

public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        char max = s[0];
        int start = 0;
        int end = 0;

        // Use a sliding window
        while (end < s.Length)
        {
            // Add the char at the "end" index to the set
            if (freq.ContainsKey(s[end]))
            {
                freq[s[end]]++;
            }
            else
            {
                freq.Add(s[end], 1);
            }

            // Check if a new max has been introduced
            if (freq[max] <= freq[s[end]])
            {
                max = s[end];
            }

            // Check if this string is achievable with k replacements
            if (freq[max] + k < end-start+1)
            {
                if (freq[s[start]] != 1)
                {
                    freq[s[start]]--;
                }
                else
                {
                    freq.Remove(s[start]);
                }
                start++;
            }
            end++;
        }

        return end - start;
    }
}