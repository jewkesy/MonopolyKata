using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace MonopolyKataTests
{
    public class DieTests
    {
        
        [Test]
        public void TestThatOnly2DieAreAllowed()
        {
            
        }

        [Test]
        public void TestThatTheLowestPossibleTotalScoreIs2()
        {
            
        }

        [Test]
        public void TestThatTheHighstPossibleTotalScoreIs12()
        {
            MonopolyKata.Interfaces.IDice mockedDice = MockRepository.GenerateMock<MonopolyKata.Interfaces.IDice>();
            mockedDice.Expect(x => x.RollDice).Return(12);

            mockedDice.VerifyAllExpectations();
        }

        [Test]
        public void TestThatASingleDieCannotBeLowerThan1()
        {

        }

        [Test]
        public void TestThatASingleDieCannotBeHigherThan6()
        {

        }
    }
}
