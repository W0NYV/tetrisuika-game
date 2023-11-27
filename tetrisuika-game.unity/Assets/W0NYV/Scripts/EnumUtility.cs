using System;
using System.Collections.Generic;

public static class EnumUtility {

    public static int GetTypeNum<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Length;
    }

    public static T GetRandom<T>() where T : Enum
    {
        int no = UnityEngine.Random.Range(0, GetTypeNum<T>());
        return NoToType<T>(no);
    }

    public static T GetRandomWithOutZero<T>() where T : Enum
    {
        int no = UnityEngine.Random.Range(1, GetTypeNum<T>());
        return NoToType<T>(no);
    }

    public static T NoToType<T>(int targetNo) where T : Enum
    {
        return (T)Enum.ToObject(typeof(T), targetNo);
    }

}