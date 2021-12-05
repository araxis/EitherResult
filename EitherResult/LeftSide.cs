namespace EitherResult;

internal class Left<TL, TR> : Either<TL, TR>
{
    public Left(TL left)
    {
        
        LeftValue = left;
    }

    internal override TL LeftValue { get; }

    internal override TR RightValue => throw new Exception("Tried to get Right from a Left");

    public override bool IsLeft => true;
    public override bool IsRight => false;
}