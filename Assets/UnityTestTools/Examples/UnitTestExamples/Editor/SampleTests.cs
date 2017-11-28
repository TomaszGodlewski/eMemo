using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine;


namespace UnityTest


{
    [TestFixture]
    [Category("Sample Tests")]
    public class SampleTests
    {
		
		[Test]
		[Category("Create objects of class GameController Test")]
		public void instanceOfDefaultConstructor()
		{	
			GameController test = new GameController ();
			Assert.IsInstanceOf<GameController> (test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void notNullDefaultConstructor()
		{	
			GameController test = new GameController ();
			Assert.NotNull (test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void areSameDefaultConstructor()
		{	
			GameController test = new GameController ();
			Assert.AreSame (test, test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void instanceOfParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.IsInstanceOf<GameController> (test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void notNullParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.NotNull (test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void areSameParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.AreSame (test, test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void areNotSameDefaultParametrizedConstructor1()
		{	
			GameController test = new GameController ();
			GameController test2 = new GameController (16);
			Assert.AreNotSame (test, test2);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void areNotSameParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			GameController test2 = new GameController (24);
			Assert.AreNotSame (test, test2);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void instanceOfParametrizedConstructor2()
		{	
			GameController test = new GameController (16,false,20f);
			Assert.IsInstanceOf<GameController> (test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void notNullParametrizedConstructor2()
		{	
			GameController test = new GameController (16,false,20f);
			Assert.NotNull (test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void areSameParametrizedConstructor2()
		{	
			GameController test = new GameController (16,false,20f);
			Assert.AreSame (test, test);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void areNotSameDefaultParametrizedConstructor2()
		{	
			GameController test = new GameController ();
			GameController test2 = new GameController (16,false,20f);
			Assert.AreNotSame (test, test2);
		}

		[Test]
		[Category("Create objects of class GameController Test")]
		public void areNotSameParametrizedConstructor2()
		{	
			GameController test = new GameController (16,false,20f);
			GameController test2 = new GameController (24,false,20f);
			Assert.AreNotSame (test, test2);
		}

		[Test]
		[Category("Class GameController Data Structures Test")]
		public void containsbButtonsParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.Contains (test.button2,test.bButtons);
		}

		[Test]
		[Category("Class GameController Data Structures Test")]
		public void isNotNullbButtonsParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.IsNotNull (test.bButtons);
		}

		[Test]
		[Category("Class GameController Data Structures Test")]
		public void isNullbButtons3ParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.IsNull (test.bButtons[3]);
		}

		[Test]
		[Category("Class GameController Data Structures Test")]
		public void bButtonsTabInstTest()
		{
			GameController test = new GameController (16);
			Assert.IsInstanceOf  <Button[]> (test.bButtons);
		
		}

		[Test]
		[Category("Class GameController Data Structures Test")]
		public void bButtonsTabNotInsTest()
		{
			GameController test = new GameController (16);
			Assert.IsNotInstanceOf  <Button> (test.bButtons);
		
		}
				
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void bButtonsTabNotNullTest()
		{
			GameController test = new GameController (16);					
			Assert.IsNotNull(test.bButtons);
		
		}
				
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void sButtonFacesTabInstTest()
		{
			GameController test = new GameController (16);
			Assert.IsInstanceOf  <String[]> (test.sButtonFaces);
		
		}
		
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void sButtonFacesTabNotInsTest()
		{
			GameController test = new GameController (16);
			Assert.IsNotInstanceOf  <String> (test.sButtonFaces);
		
		}
		
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void sFacesArrInstTest()
		{
			GameController test = new GameController (16);
			Assert.IsInstanceOf  <System.Collections.ArrayList> (test.sFaces);
		
		}
		
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void sFacesArrNotInsTest()
		{
			GameController test = new GameController (16);
			Assert.IsNotInstanceOf  <String> (test.sFaces);
		
		}
		
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void compareFacesArrInstTest()
		{
			GameController test = new GameController (16);
			Assert.IsInstanceOf  <System.Collections.ArrayList> (test.compareFaces);
		
		}
		
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void compareFacesArrNotInsTest()
		{
			GameController test = new GameController (16);
			Assert.IsNotInstanceOf  <String> (test.compareFaces);
		
		}
		
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void compareIdxArrInstTest()
		{
			GameController test = new GameController (16);
			Assert.IsInstanceOf  <System.Collections.ArrayList> (test.compareIdx);
		
		}
		
		[Test]
		[Category("Class GameController Data Structures Test")]
		public void compareIdxArrNotInsTest()
		{
			GameController test = new GameController (16);
			Assert.IsNotInstanceOf  <String> (test.compareIdx);
		
		}




		[Test]
		[Category("Class GameController Fields Test")]
		public void tabSizeParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.AreEqual (16, test.getTabSize());
		}

		[Test]
		[Category("Class GameController Methods Test")]
		public void timeModeParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.IsTrue (test.getTimeMode());
		}


		[Test]
		[Category("Class GameController Fields Test")]
		public void timeLimitParametrizedConstructor2()
		{	
			GameController test = new GameController (16,false,20f);
			Assert.AreEqual (20f, test.getTimeLimit());
		}

		[Test]
		[Category("Class GameController Fields Test")]
		public void timeModeParametrizedConstructor2()
		{	
			GameController test = new GameController (16,false,20f);
			Assert.IsFalse (test.getTimeMode());
		}

		[Test]
		[Category("Class GameController Methods Test")]
		public void createButtonParametrizedConstructor1()
		{	
			GameController test = new GameController (16);
			Assert.IsTrue (test.createButtonsArrays());
		}

		[Test]
		[Category("Class GameController Methods Test")]
		public void compStringTrueTest()
		{
			GameController test = new GameController (16);
			Assert.IsTrue (test.compString("STRING1","STRING2"));
		
		}

		[Test]
		[Category("Class GameController Methods Test")]
		public void compStringFalseTest()
		{
			GameController test = new GameController (16);
			Assert.IsFalse (test.compString("STRING1","STRING1"));

		}

    }
}
