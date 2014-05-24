using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurl;
using NUnit.Framework;


namespace Nurl.Test
{
    [TestFixture]
    public class MesTests
    {
    	///TO DO
        [Test]
        public void Should_show_the_content_of_a_page()
        {
            //var 
            ////given
            //var command = null; //votre implémentation
            //var coso = new Commander();
			//var contenu = coso.Get();
			
            //cons

            ////when
            //var result = command.Show(url); //exemple d'implémentation

            ////then

            //Assert.That(result, Is.EqualTo("<h1>hello</h1>"));
        }
	

        [Test]
        public void Should_save_the_content_of_a_page_on_disk()
        {
        }

        [Test]
        public void Should_test_the_load_of_the_content_of_a_page()
        {
        }

        [Test]
        public void Should_show_the_average_of_load_time_of_the_content_of_a_page()
        {
            
        }

		[Test]
		[TestCase("get","-url")]
		//[TestCase("test","-url")]
		public void Should_test_dictionnary_couple(string given, string coming)
		{
			var com = new Argument();
			com.AddArgumentCouple(given,coming);
			var message = com.GetValue(given);
			Assert.AreEqual(coming,message);
		}


		[Test]
		[TestCase("asdaze","asdaze")]
		public void Should_test_normalisation_method(string given,string coming)
		{
			var com = new Commander ();
			var message = com.Normalisation (given);
			Assert.AreEqual (coming, message);
		}
				
		[Test]
		//tester si le debut et la fin du rendu sont <html></html>
		public void Should_be_a_webside_url()
		{
			
		}
    }
}
