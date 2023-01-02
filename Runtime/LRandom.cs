//https://github.com/JiepengTan/LockstepMath

using System;
using System.Collections.Generic;
using Lockstep.Math;

namespace Lockstep {

    public partial class LRandom:LBaseRandom<int> { }
    public partial class LDebugRandom:LBaseRandom<long> { }

    public partial class LBaseRandom<T> {
        static Math.Random _i = new Math.Random();
        static Dictionary<int, ulong> _tick2Id = new Dictionary<int, ulong>();
        public static LFloat value => _i.value;
        
        public static void Reset() {
            _i.randSeed = 3274;
        }

        public static LFloat Next01() {
            return new LFloat(true, _i.Range(0, (uint) LFloat.Precision));
        }

        public static uint Next() {
            return _i.Next();
        }

        public static uint Next(uint max) {
            return _i.Next(max);
        }

        public static int Next(int max) {
            return _i.Next(max);
        }

        public static uint Range(uint min, uint max) {
            return _i.Range(min, max);
        }

        public static int Range(int min, int max) {
            return _i.Range(min, max);
        }

        public static LFloat Range(LFloat min, LFloat max) {
            return _i.Range(min, max);
        }

        public static int CurTick { get; set; }

        public static void RollbackTo(int tick) {
            _i.randSeed = _tick2Id[tick];
        }

        public static void Backup(int tick) {
            _tick2Id[tick] = _i.randSeed;
        }

        public static void Clean(int maxVerifiedTick) { }
    }
}

namespace Lockstep.Math {
    public partial class RandomService  {
        Lockstep.Math.Random _i = new Lockstep.Math.Random();
        public LFloat value => _i.value;

        public int GetHash(ref int idx) {
            return (int) _i.randSeed;
        }

        public void DumpStr(System.Text.StringBuilder sb, string prefix) {
            sb.AppendLine("RandomService " + _i.randSeed);
        }

        public void Reset() {
            _i = new Lockstep.Math.Random();
        }

        public uint Next() {
            return _i.Next();
        }

        public uint Next(uint max) {
            return _i.Next(max);
        }

        public int Next(int max) {
            return _i.Next(max);
        }

        public uint Range(uint min, uint max) {
            return _i.Range(min, max);
        }

        public int Range(int min, int max) {
            return _i.Range(min, max);
        }

        public LFloat Range(LFloat min, LFloat max) {
            return _i.Range(min, max);
        }

        public int CurTick { get; set; }
        Dictionary<int, ulong> _tick2Id = new Dictionary<int, ulong>();

        public void RollbackTo(int tick) {
            _i.randSeed = _tick2Id[tick];
        }

        public void Backup(int tick) {
            _tick2Id[tick] = _i.randSeed;
        }

        public void Clean(int maxVerifiedTick) { }
    }

    public partial struct Random {
        public ulong randSeed;

        public Random(uint seed = 17) {
            randSeed = seed;
        }

        public LFloat value => new LFloat(true, Range(0, (int) LFloat.Precision));

        public uint Next() {
            randSeed = randSeed * 1103515245 + 36153;
            return (uint) (randSeed / 65536);
        }

        // range:[0 ~(max-1)]
        public uint Next(uint max) {
            if (max == 0u) return 0u;
            return Next() % max;
        }

        public LVector2 NextVector2() {
            return new LVector2(true, Next((uint) LFloat.Precision), Next((uint) LFloat.Precision));
        }

        public LVector3 NextVector3() {
            return new LVector3(true, Next((uint) LFloat.Precision), Next((uint) LFloat.Precision),
                Next((uint) LFloat.Precision));
        }

        public int Next(int max) {
            return (int) (Next() % max);
        }

        // range:[min~(max-1)]
        public uint Range(uint min, uint max) {
            if (min > max)
                throw new ArgumentOutOfRangeException("minValue",
                    string.Format("'{0}' cannot be greater than {1}.", min, max));

            uint num = max - min;
            return this.Next(num) + min;
        }

        public int Range(int min, int max) {
            if (min >= max - 1)
                return min;
            int num = max - min;

            return this.Next(num) + min;
        }

        public LFloat Range(LFloat min, LFloat max) {
            if (min > max)
                throw new ArgumentOutOfRangeException("minValue",
                    string.Format("'{0}' cannot be greater than {1}.", min, max));

            var num = (max._val - min._val);
            if (num == 0L) return min;
            return new LFloat(true, Next((uint) num) + min._val);
        }
    }
#if false
    public class LRandom {
        private static Random _i = new Random(3274);
        public static LFloat value => _i.value;
        public static uint Next(){return _i.Next();}
        public static uint Next(uint max){return _i.Next(max);}
        public static int Next(int max){return _i.Next(max);}
        public static uint Range(uint min, uint max){return _i.Range(min, max);}
        public static int Range(int min, int max){return _i.Range(min, max);}
        public static LFloat Range(LFloat min, LFloat max){return _i.Range(min, max);}
    }
#endif
}