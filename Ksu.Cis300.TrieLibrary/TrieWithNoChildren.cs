/* TrieWithNoChildren.cs
 * Written by: Milan Minocha
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// Class for Tries that have no children.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Boolean that is true if the trie contains the empty string.
        /// </summary>
        private Boolean _containsEmptyString = false;
        //private ITrie onlyChild;
        //private char childsLabel;
        

        /// <summary>
        /// Constructor for the trie with no children class.
        /// </summary>
        public TrieWithNoChildren()
        {
            /*if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }*/
        }

        /// <summary>
        /// Adds to the trie with no children, if the string is not empty/invalid, makes a trie with one child.
        /// </summary>
        /// <param name="s">String to be added to the trie.</param>
        /// <returns>The new trie.</returns>
        public ITrie Add(string s)
        {
            if (s != "")
            {
                TrieWithOneChild newTrie = new TrieWithOneChild(s, _containsEmptyString);
                return newTrie;
            }
            else
            {
                _containsEmptyString = true;
                return this;
            }

            

        }

        /// <summary>
        /// Returns whether or not the trie contains a string.
        /// </summary>
        /// <param name="s">String to be checked.</param>
        /// <returns>Boolean if false or true whether the trie contains the string.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _containsEmptyString;
            }
            else
            {
                return false;
            }
        }
    }
}
