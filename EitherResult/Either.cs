namespace EitherResult;

public abstract class Either<TL, TR>
{
    internal abstract TL LeftValue { get; }
    internal abstract TR RightValue { get; }
    public abstract bool IsLeft { get; }
    public abstract bool IsRight { get; }
}