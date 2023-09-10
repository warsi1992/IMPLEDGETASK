using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImpledgeTask
{
    public class Test
    {
        public Test()
        {
            FindLongestAndSecondLongestCompoundedWords_ShouldReturnCorrectResults();
        }

        [Fact]
        public void FindLongestAndSecondLongestCompoundedWords_ShouldReturnCorrectResults()
        {
            try
            {

                var words = new List<string> { "cat", "cats", "dog", "catsdog", "dogcat", "bird" };
                var finder = new CompoundedWordFinder();
                var result = finder.FindLongestAndSecondLongestCompoundedWords(words);
                Assert.Equal("catsdog", result.Longest);
                Assert.Equal("dogcat", result.SecondLongest);
                Console.ReadLine();


                //IF WANTED TO AUTOMATE THE TEST COMMENT ABOVE CODE AND UNCOMMENT BELOW CODE

                //CompoundedWordFinder cs = new CompoundedWordFinder();
                //var words = new List<string>();
                //Console.WriteLine("Please enter Total number of words to be inserted in List to be checked longest and second Longest Compund Word :");
                //var length = Convert.ToInt32(Console.ReadLine());
                //for (var i = 0; i < length; i++)
                //{
                //    var number = i + 1;
                //    Console.WriteLine("Please Enter " + number + " Word");
                //    var val = Console.ReadLine();
                //    words.Add(val);
                //}
                //Console.WriteLine("Please Enter Longest Compound Word to Compared ");
                //var longcomword = Console.ReadLine();
                //Console.WriteLine("Please Enter Second Longest Compound Word to Compared ");
                //var longsecondcomword = Console.ReadLine();
                //var result = cs.FindLongestAndSecondLongestCompoundedWords(words);
                //Assert.Equal(longcomword, result.Longest);
                //Assert.Equal(longsecondcomword, result.SecondLongest);
                //Console.ReadLine();
            }
            catch (Exception EX)
            {

                Console.WriteLine("ERROR: "+EX.Message);
                Console.ReadLine();
            }
           
        }
    }
}
