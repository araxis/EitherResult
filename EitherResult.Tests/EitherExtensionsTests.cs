using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace EitherResult.Tests
{
    public class EitherExtensionsTests
    {
        [Fact]
        public void LeftMethodCreateLeft()
        {
            
            var result = Either<int,string>.Left(12);
            result.Should().BeOfType<Left<int, string>>();
        }

        [Fact]
        public void RightMethodCreateRight()
        {
            
            var result = Either<int,string>.Right("Test");
            result.Should().BeOfType<Right<int, string>>();
        }

        [Fact]
        public void AssignValueWithTypeOfTLeftCreateLeft()
        {
            
            Either<int,string> result =12;
            result.Should().BeOfType<Left<int, string>>();
        }

        [Fact]
        public void AssignValueWithTypeOfTRightCreateRight()
        {
            
            Either<int,string> result ="Test";
            result.Should().BeOfType<Right<int, string>>();
        }

        [Fact]
        public void SwitchExecuteOnLeftMethodWhenValueIsLeft()
        {
            
            var result = Either<int,string>.Left(12);
            var switchTest = -1;

            result.Switch(left => switchTest =1, right =>  switchTest = 2);

            switchTest.Should().Be(1);
        }

        [Fact]
        public void SwitchExecuteOnRightMethodWhenValueIsRight()
        {
            
            var result = Either<int,string>.Right("Test");
            var switchTest = -1;

            result.Switch(left => switchTest =1, right =>  switchTest = 2);

            switchTest.Should().Be(2);
        }

        [Fact]
        public void MapReturnEitherOfTypeLeftWhenParameterIsLeft()
        {
            
            var baseEither = Either<int,string>.Left(12);
            var switchTest = -1;
            var transformLeftResult = 1;
            var transformRightResult = 2;

           var mapEither= baseEither.Map(left => transformLeftResult, right =>transformRightResult);
           mapEither.Switch(left=> switchTest=left,right => switchTest=right);

           using var scope = new AssertionScope();
           mapEither.Should().BeOfType<Left<int, int>>();
           switchTest.Should().Be(transformLeftResult);
        }

        [Fact]
        public void MapReturnEitherOfTypeRightWhenParameterIsRight()
        {
            
            var baseEither = Either<int,string>.Right("Test");
            var switchTest = -1;
            var transformLeftResult = 1;
            var transformRightResult = 2;

            var mapEither= baseEither.Map(left => transformLeftResult, right =>transformRightResult);
            mapEither.Switch(left=> switchTest=left,right => switchTest=right);

            using var scope = new AssertionScope();
            mapEither.Should().BeOfType<Right<int, int>>();
            switchTest.Should().Be(transformRightResult);
        }

        [Fact]
        public void FoldReturnResultOfTransformLeftWhenParameterIsLeft()
        {
            
            var baseEither = Either<int,string>.Left(12);
            var switchTest = -1;
            var transformLeftResult = 1;
            var transformRightResult = 2;
            var foldResult= baseEither.Fold(left => transformLeftResult, right =>transformRightResult);
          
            foldResult.Should().Be(transformLeftResult);
        }

        [Fact]
        public void FoldReturnResultOfTransformRightWhenParameterIsRight()
        {
            
            var baseEither = Either<int,string>.Right("Test");
            var switchTest = -1;
            var transformLeftResult = 1;
            var transformRightResult = 2;
            var foldResult= baseEither.Fold(left => transformLeftResult, right =>transformRightResult);
          
            foldResult.Should().Be(transformRightResult);
        }
    }
}