namespace EitherResult;

public abstract class Either<TL, TR>
{
    internal abstract TL LeftValue { get; }
    internal abstract TR RightValue { get; }
    internal abstract bool IsLeft { get; }
}