namespace EitherResult;

public abstract class Either<TL, TR>
{
    internal abstract TL LeftValue { get; }
    internal abstract TR RightValue { get; }
    internal abstract bool IsLeft { get; }

    public static Either<TL, TR> Left(TL value) => new Left<TL, TR>(value);
    public static Either<TL, TR> Right(TR value) => new Right<TL, TR>(value);

    public static implicit operator Either<TL, TR>(TL value) => Left(value);
    public static implicit operator Either<TL, TR>(TR value) => Right(value);
}