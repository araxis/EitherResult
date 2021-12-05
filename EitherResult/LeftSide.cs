namespace EitherResult;

public class Left<TL, TR> : Either<TL, TR>
{
    internal Left(TL left)
    {
        
        LeftValue = left;
    }

    internal override TL LeftValue { get; }

    internal override TR RightValue => throw new Exception("Tried to get Right from a Left");

    internal override bool IsLeft => true;


  
}