namespace EitherResult;

internal class Right<TL, TR> : Either<TL, TR>
{
    public Right(TR right)
    {
        RightValue = right;
    }

    internal override TL LeftValue => throw new Exception("Tried to get Left from a Right");

    internal override TR RightValue { get; }

    public override bool IsLeft => true;
    public override bool IsRight => false;
}