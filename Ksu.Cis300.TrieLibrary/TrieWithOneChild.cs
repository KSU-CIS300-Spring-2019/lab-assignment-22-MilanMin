/* TrieWithOneChild.cs
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
    /// Class for tries with one child.
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Boolean on whether or not the trie contains the empty string.
        /// </summary>
        private Boolean _containsEmptyString;
        /// <summary>
        /// The trie that is the only child of this trie.
        /// </summary>
        private ITrie _onlyChild;
        /// <summary>
        /// The char that this trie node contains.
        /// </summary>
        private char _childsLabel;

        /// <summary>
        /// The constructor for the trie with one child class.
        /// </summary>
        /// <param name="s">The string to be added.</param>
        /// <param name="storeEmptyString">Whether or not the empty string is contained.</param>
        public TrieWithOneChild(string s, bool storeEmptyString)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }

            _containsEmptyString = storeEmptyString;
            _childsLabel = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1)); //+s.Substring(1);?????
        }

        /// <summary>
        /// Adds a string to the trie.
        /// </summary>
        /// <param name="s">The string to be added.</param>
        /// <returns>The new trie.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _containsEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            if (s[0] == _childsLabel)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }

            return new TrieWithManyChildren(s, _containsEmptyString, _childsLabel, _onlyChild);


        }

        /// <summary>
        /// Returns whether or not the trie contains the given string.
        /// </summary>
        /// <param name="s">The given string.</param>
        /// <returns>Whether or not the trie contains the given string. (boolean)</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _containsEmptyString;
            }
            else
            {
                if (s[0] == _childsLabel)
                {
                    return _onlyChild.Contains(s.Substring(1));
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
