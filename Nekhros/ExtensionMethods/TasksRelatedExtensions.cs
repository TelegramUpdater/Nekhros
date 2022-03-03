namespace System.Threading.Tasks
{
    internal static class TasksRelatedExtensions
    {
        public static async Task TryExecute(this Task task)
        {
            try
            {
                await task;
            }
            catch
            {

            }
        }

        public static async Task TryExecute<E>(this Task task) where E : Exception
        {
            try
            {
                await task;
            }
            catch(E)
            {

            }
        }

        public static async Task<T?> TryExecute<T>(this Task<T> task)
        {
            try
            {
                return await task;
            }
            catch
            {
                return default;
            }
        }

        public static async Task TryExecute(this Task task, Action<Exception> except)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                except(ex);
            }
        }

        public static async Task TryExecute(this Task task, Func<Exception, Task> except)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                await except(ex);
            }
        }

        public static async Task<T?> TryExecute<T>(this Task<T> task, Action<Exception> except)
        {
            try
            {
                return await task;
            }
            catch (Exception ex)
            {
                except(ex);
                return default;
            }
        }

        public static async Task<T> TryExecute<T>(this Task<T> task, Func<Exception, Task<T>> except)
        {
            try
            {
                return await task;
            }
            catch (Exception ex)
            {
                return await except(ex);
            }
        }

        public static async Task<T> TryExecute<T>(this Task<T> task, Func<Exception, T> except)
        {
            try
            {
                return await task;
            }
            catch (Exception ex)
            {
                return except(ex);
            }
        }

        public static async Task<T> TryExecute<T, E>(this Task<T> task, Func<E, T> except)
            where E : Exception
        {
            try
            {
                return await task;
            }
            catch (E ex)
            {
                return except(ex);
            }
        }

        public static async Task<T> TryExecute<T, E>(this Task<T> task, Func<E, Task<T>> except)
            where E : Exception
        {
            try
            {
                return await task;
            }
            catch (E ex)
            {
                return await except(ex);
            }
        }

        public static async Task<T?> TryExecute<T, E>(this Task<T> task, Action<E> except)
            where E : Exception
        {
            try
            {
                return await task;
            }
            catch (E ex)
            {
                except(ex);
                return default;
            }
        }
    }
}
