namespace EitherResult;

public static class EitherExtensions{


    public static void Switch<TL,TR>(this Either<TL,TR> result,Action<TL> onLeft,Action<TR> onRight)
    {
        if (onLeft is null) throw new ArgumentNullException(nameof(onLeft));
        if (onRight is null) throw new ArgumentNullException(nameof(onRight));
        if (result.IsLeft) onLeft(result.LeftValue);
        else onRight(result.RightValue);
    }


    public static  Either<TU, TS> Map<TL,TR,TU,TS>(this Either<TL,TR> result,Func<TL, TU> transformLeft, Func<TR, TS> transformRight)
    {
        if (transformLeft is null) throw new ArgumentNullException(nameof(transformLeft));
        if (transformRight is null) throw new ArgumentNullException(nameof(transformRight));
        if (result.IsLeft)
        {
            var leftValue = transformLeft(result.LeftValue);
            return Either<TU, TS>.Left(leftValue);
        }
        var rightValue = transformRight(result.RightValue);
        return Either<TU, TS>.Right(rightValue);
    }

    public static  T Fold<TL,TR,T>(this Either<TL,TR> result,Func<TL, T> transformLeft, Func<TR, T> transformRight)
    {
        if (transformLeft is null) throw new ArgumentNullException(nameof(transformLeft));
        if (transformRight is null) throw new ArgumentNullException(nameof(transformRight));
        return result.IsLeft ? transformLeft(result.LeftValue) : transformRight(result.RightValue);
    }

}