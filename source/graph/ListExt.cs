using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class ListExt// make this class somehow more responsable for the word
                    // find a way to separate the search algorithm from the functions
{
    public static List<T> Sort<T>(this T[] input)where T:IComparable<T>
        {
            List<T> ret = new List<T>();
            ret.Add(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                var a = input[i];
                
                     if (a.CompareTo(ret.Last()) >= 0)  ret.Add(a);
                else if (a.CompareTo(ret[0]) <=0)       ret.Insert(0, a);
                else                                    ret.Append(a);
            }
            return ret;
        }
    public static List<int> Describe<T>(this T[] input) where T : IComparable<T>
        {
            List<T> value = new List<T>();
            List<int> id=new List<int>();
            value.Add(input[0]);
            id.Add(0);
            for (int i = 1; i < input.Length; i++)
            {
                var a = input[i];

                if (a.CompareTo(value.Last()) >= 0)
                {
                    value.Add(a);
                    id.Add(i);
                }
                else if (a.CompareTo(value[0]) <= 0)
                {
                    value.Insert(0, a);
                    id.Insert(0, i);
                }
                else
                {
                    
                    var v=value.Mind(a);
                    value.Match(v,a);
                    id.Match(v,i);
                }
            }
            return id;
        }
    public static void Match<T>(this List<T> collection,int index,T value)
    {
        if (index >= collection.Count)
            collection.Add(value);
        else
            collection.Insert(index, value);
    }
    public static List<T> Group<T>(this List<T> collection)
       where T : IComparable<T>
    {
        var ret = new List<T>();
        foreach (var i in collection)
            ret.Append(i);
        return ret;
    }
    public static List<T> Group<T>(this T[] collection)
    where T : IComparable<T>
    {
        var ret = new List<T>();
        foreach (var i in collection)
            ret.Append(i);
        return ret;
    }
    public static void Steal<T>(this List<T> to, List<T> from)
    {
        to.Add(from.Pop());
    }
    public static T PopS<T>(this List<T> list)
    {
        var ret = list[0];
        list.RemoveAt(0);
        return ret;
    }
    public static T Peek<T>(this List<T> list)
        => list[list.Count() - 1];

    public static T Pop<T>(this List<T> list)
    {
        var id = list.Count() - 1;
        var ret = list[id];
        list.RemoveAt(id);
        return ret;
    }
    public static T FAdd<T>(this List<T> list, T value)
        where T : IComparable<T>
    {
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;

        var com = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            com = list[c].CompareTo(value);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else
            {
                return list[c];
            }

        }
        if (c >= list.Count())
            list.Add(value);

        else
        {
            if (com < 0) c++;
            list.Insert(c, value);
        }

        return value;
    }
    public static int Mind<T>(this List<T> list, T value)
        where T : IComparable<T>
    {
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;

        var com = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            com = list[c].CompareTo(value);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else
            {
                return c;
            }

        }

        if (c >= list.Count())
            return list.Count();
        else
        {
            if (com < 0) c++;
            return c;
        }
    }
    public static bool Append<T>(this List<T> list, T value)
        where T : IComparable<T>
    {
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;

        var com = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            com = list[c].CompareTo(value);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else
            {
                list[c] = value;
                return false;
            }

        }

        if (c >= list.Count())
            list.Add(value);

        else
        {
            if (com < 0) c++;
            list.Insert(c, value);
        }

        return true;
    }
    public static void Delete<T>(this List<T> list, T value)
       where T : IComparable<T>
    {
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;

        var com = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            com = list[c].CompareTo(value);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else list.RemoveAt(c);

        }
    }

    /*
    public static T Find<T>(this List<T> a, T t,out bool found)
        where T : IComparable<T>
    {
        int l = 0;
        int r = a.Count() - 1;
        int c = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            var com = a[c].CompareTo(t);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else
            {
                found = true;
                return a[c];
            }

        }
        found = false;
        return default(T);
    }*/

    public static bool Find<T, E, F>(this T list, F element, out E result)//only a collection sorted backwords
        where T : ICollection<E>
        where E : IComparable<F>
    {
        if (list == null)
        {
            result = default(E);
            return false;
        }
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            var com = list.ElementAt(c).CompareTo(element);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else
            {
                result = list.ElementAt(c);
                return true;
            }
        }
        result = default(E);
        return false;
    }
    public static bool FindId<T>(this List<T>list, T element, out int result)//only a collection sorted backwords
        where T:IComparable<T>
    {
        if (list == null)
        {
            result = -1;
            return false;
        }
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            var com = list.ElementAt(c).CompareTo(element);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else
            {
                result = c;
                return true;
            }
        }
        result = -1;
        return false;
    }
    public static bool Have<T, E>(this List<T> list, E element)//only a collection sorted backwords
        where T : IComparable<E>
    {
        if (list == null)
        {
            return false;
        }
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            var com = list.ElementAt(c).CompareTo(element);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else
            {
                return true;
            }
        }
        return false;
    }/*
        public static int FindID<E>(this List<E> a, E e)
            where E : IComparable<E>
        {
            int l = 0;
            int r = a.Count() - 1;

            int c = 0;
            while (l <= r)
            {
                c = (l + r) / 2;
                var com = a[c].CompareTo(e);
                if (com > 0) r = c - 1;
                else if (com < 0) l = c + 1;
                else return c;


            }
            return -1;
        }*/
    public static int FindID<T, E>(this List<T> list, E element)
        where T : IComparable<E>
    {
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            var com = list.ElementAt(c).CompareTo(element);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else return c;


        }
        return -1;
    }
    public static int FindID<T, E>(this T list, E element)
        where T : ICollection<E>
        where E : IComparable<E>
    {
        int l = 0;
        int r = list.Count() - 1;

        int c = 0;
        while (l <= r)
        {
            c = (l + r) / 2;
            var com = list.ElementAt(c).CompareTo(element);
            if (com > 0) r = c - 1;
            else if (com < 0) l = c + 1;
            else return c;


        }
        return -1;
    }

}
