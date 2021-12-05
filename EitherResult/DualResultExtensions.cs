namespace EitherResult;

public static class DualResultExtensions{

    public static Either<TL,TR> Left<TL,TR>(this TL left) => new Left<TL, TR>(left);
    public static Either<TL,TR> Right<TL,TR>(this TR right) => new Right<TL, TR>(right);
    public static void Switch<TL,TR>(this Either<TL,TR> result,Action<TL> onLeft,Action<TR> onRight)
    {
        if (onLeft is null) throw new ArgumentNullException(nameof(onLeft));
        if (onRight is null) throw new ArgumentNullException(nameof(onRight));
        if (result.IsLeft) onLeft(result.LeftValue);
        else onRight(result.RightValue);
    }



}