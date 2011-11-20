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
        [Ignore]
        public void TestThatOnly2DieAreAllowed()
        {
            
        }

        [Test]
        [Ignore]
        public void TestThatTheLowestPossibleTotalScoreIs2()
        {
            
        }

        [Test]
        [Ignore]
        public void TestThatTheHighstPossibleTotalScoreIs12()
        {
            MonopolyKata.Interfaces.IDice mockedDice = MockRepository.GenerateMock<MonopolyKata.Interfaces.IDice>();
            mockedDice.Expect(x => x.RollDice).Return(12);

            mockedDice.VerifyAllExpectations();
        }

        [Test]
        [Ignore]
        public void TestThatASingleDieCannotBeLowerThan1()
        {

        }

        [Test]
        [Ignore]
        public void TestThatASingleDieCannotBeHigherThan6()
        {

        }
    }
}
