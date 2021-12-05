namespace EitherResult;

public class Right<TL, TR> : Either<TL, TR>
{
    internal Right(TR right)
    {
        RightValue = right;
    }

    internal override TL LeftValue => throw new Exception("Tried to get Left from a Right");

    internal override TR RightValue { get; }

    internal override bool IsLeft => false;

}