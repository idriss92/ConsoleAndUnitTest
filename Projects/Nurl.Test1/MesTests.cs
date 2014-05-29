using System;
using Nurl;
using NUnit.Framework;
using System.IO;
<<<<<<< HEAD
using System.Net;
=======
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nurl.Test1
{
    [TestFixture]
    public class MesTests
    {
<<<<<<< HEAD
        Verification verifie = new Verification();

        string[] args = Environment.GetCommandLineArgs();

=======
        string[] args = Environment.GetCommandLineArgs();


>>>>>>> ba203b89503b953f14b383286774297f32c27f87
        #region Test Commander Done
        [Test]
        //[TestCase("nurl.exe get -url 'http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric'")]
        public void Should_show_the_content_of_a_page()
        {
<<<<<<< HEAD
            var arg = new String[] { "get", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric" };
            string recu = null;
            var contenu = new Commander();
            recu = contenu.Get(arg);
            Assert.IsNotNull(recu);
        }

=======
            var contenu = new Commander();
            var recu = contenu.Get(args);
            Assert.IsNotNull(recu);
        }

        #endregion
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
       
        [Test]
        public void Should_save_the_content_of_a_page_on_disk()
        {
<<<<<<< HEAD
            var arg = new String[] { "get", "-url", "http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric", "-save ", @"C:\Users\SI\Documents\bitch.txt" };
            var debu = new Commander();
            debu.GetSave(arg);
            Assert.IsTrue(File.Exists(@"C:\Users\SI\Documents\bitch.txt"));

        }


        [Test]
        public void Should_test_the_load_time_of_the_content_of_a_page()
        {
            //long i = 22 ;
            var de = new String []{"test", "-url" ,"http://www.yahoo.fr", "-times", "5"};
            var debut = new Commander();
            var retour = debut.LoadTime(de);
            Assert.IsNotNull(retour);
        }

        
        [Test]
        [TestCase(600)]
        public void Should_show_the_average_of_load_time_of_the_content_of_a_page(long given)
        {
            var arg = new String []{"test", "-url" ,"http://www.yahoo.fr", "-times", "5","avg"};
            var depart = new Commander();
            var init = depart.LoadTimeAverage(arg);
            Assert.IsTrue(init > given);
        }

        #endregion

=======
            var debut = new Commander();
            debut.GetSave(args);
            Assert.IsTrue(File.Exists(args[3].Replace("\"","/")));
        }

        [Test]
        public void Should_test_the_load_of_the_content_of_a_page()
        {
        }

        [Test]
        public void Should_show_the_average_of_load_time_of_the_content_of_a_page()
        {
        }

>>>>>>> ba203b89503b953f14b383286774297f32c27f87

        #region Test Argument Not Done
        [Test]
        [TestCase("get", "-url")]
<<<<<<< HEAD
=======
        [TestCase("test","-url")]
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
        public void Should_test_dictionnary_couple(string given, string coming)
        {
            var com = new Argument();
            com.AddArgumentCouple(given, coming);
            var message = com.GetValue(given);
            Assert.AreEqual(coming, message);
        }

        [Test]
        [TestCase("get", "-url")]
        public void Should_add_key_and_value_in_dictionnary(string given1, string given2)
        {
            var comp = new Argument();
            comp.AddArgumentCouple(given1, given2);
            Assert.IsNotNull(comp);
 
        }


        #endregion

        #region Test Verification Done
        [Test]
<<<<<<< HEAD
        [TestCase("\"asdaze\"","asdaze")]
=======
        [TestCase("asdaze","asdaze")]
>>>>>>> ba203b89503b953f14b383286774297f32c27f87
        public void Should_test_normalisation_method(string given,string coming)
        {
            var com = new Verification ();
            var message = com.Normalisation (given);
            Assert.AreEqual (coming, message);
        }
		
        [Test]
        [TestCase("http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric")]
        public void Should_be_a_webside_url(string given)
        {
            var bs = new Verification();
            var accord = bs.isUrL(given);
            Assert.IsTrue(accord);

        }


        [Test]
        [TestCase("C:/")]
        public void should_be_a_path_for_save(string given)
        { 
            var lien = new Verification();
            var message = lien.IsDirectory(given);
            Assert.IsTrue(message);
        }
        #endregion
    }
}
