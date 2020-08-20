using System;

namespace Design.Pattern.Applying.Functionals.Extensions
{
    public static class OptionExtensions
    {
        public static Option<TSource> OnTry<TSource>(this Option<TSource> option, Func<TSource, Option<TSource>> predicate)
        {
            if (option.IsNone)
                return Option<TSource>.None(option.Message);
            return option.Try(predicate);
        }

        public static Option<TSource> OnValidation<TSource>(this Option<TSource> option, Action<TSource> action)
        {
            // if (option.IsNone)
            //     return Option<TSource>.None(option.Message);
            // return option.Try(predicate);

            return option;
        }
        
        
        public static Option<TSource> OnTry<TSource>(this Option<TSource> option, Action<TSource> action)
        {
            if (option.IsNone)
                return Option<TSource>.None(option.Message);
            return option.Try(action);
        }

        public static Option<TSource> Catch<TSource>(this Option<TSource> option, Func<TSource, Option<TSource>> func)
        {
            return option;
        }
        
        public static Option<TSource> Finally<TSource>(this Option<TSource> option)
        {
            return option;
        }
    }

    public static class OptionTry
    {
        private static readonly Func<Exception, string> DefaultTryErrorHandler = exc => exc.Message;

        public static Option<TSource> Try<TSource>(this Option<TSource> option, Func<TSource, Option<TSource>> func) => InternalTry(option, func);

        // public static Option<T> Try<T>(this Option<T> option, Func<Option<T>> func)
        // {
        //     try
        //     {
        //         var optionFunc = func();
        //         if (optionFunc.IsSome) return option;
        //         return Option<T>.None(optionFunc.Message);
        //     }
        //     catch (Exception exc)
        //     {
        //         return Option<T>.None(exc.Message);
        //     }
        // }
        
        public static Option<TSource> Try<TSource>(this Option<TSource> option, Action<TSource> action)
        {
            try
            {
                if (option.IsSome)
                {
                    action(option.Value);
                    return option;
                }
                return Option<TSource>.None(option.Message);
            }
            catch (Exception exc)
            {
                return Option<TSource>.None(exc.Message);
            }
        }
        
        
        internal static Option<TSource> InternalTry<TSource>(Option<TSource> option, Func<TSource, Option<TSource>> func)
        {
            try
            {
                var optionFunc = func(option.Value);
                if (optionFunc.IsSome) return option;
                return Option<TSource>.None(optionFunc.Message);
            }
            catch (Exception exc)
            {
                return Option<TSource>.None(exc.Message);
            }
        }
    }
}