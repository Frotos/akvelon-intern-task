using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceVerificatorLib.Tests {
    
  [TestClass]
  public class BalanceVerificatorTests {
    [TestMethod]
    public void Verify_Balanced_Minus1() {
      // arrange
      string value = "{[(({}))]}";
      int expected = -1;
        
      // act
      BalanceVerificator verificator = new BalanceVerificator();
      int actual = verificator.Verify(value);
      
      // assert
      Assert.AreEqual(expected, actual);
    }
      
    [TestMethod]
    public void Verify_Balanced2_Minus1() {
      // arrange
      string value = "{[(({}{}))]}";
      int expected = -1;
        
      // act
      BalanceVerificator verificator = new BalanceVerificator();
      int actual = verificator.Verify(value);
          
      // assert
      Assert.AreEqual(expected, actual);
    }
      
    [TestMethod]
    public void Verify_Balanced3_Minus1() {
      // arrange
      string value = "{[]{()}}";
      int expected = -1;
        
      // act
      BalanceVerificator verificator = new BalanceVerificator();
      int actual = verificator.Verify(value);
        
      // assert
      Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Verify_NotBalanced_8() {
      // arrange
      string value = "[()]{}{[[()()]()}";
      int expected = 8;
        
      // act
      BalanceVerificator verificator = new BalanceVerificator();
      int actual = verificator.Verify(value);
        
      // assert
      Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Verify_NotBalanced_6() {
      // arrange
      string value = "[{}{}(]";
      int expected = 6;
        
      // act
      BalanceVerificator verificator = new BalanceVerificator();
      int actual = verificator.Verify(value);
        
      // assert
      Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Verify_UnsupportedSymbol_Exception() {
      // arrange
      string value = "()[(){S}]";
      
      // act
      BalanceVerificator verificator = new BalanceVerificator();
      int actual = verificator.Verify(value);
    }
  }
}