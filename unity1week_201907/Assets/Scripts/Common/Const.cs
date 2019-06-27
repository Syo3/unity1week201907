namespace Common {

	public static class Const {


        public const float MOVE_SPEED = 1.0f;


		public const int NUM_WIDTH  = 9;
		public const int NUM_HEIGHT = 6;

		public const float BLOCK_SIZE = 1.6f;
		public const float BLOCK_SIZE_HALF = BLOCK_SIZE / 2.0f;

		public const int GAME_END_TURN = 20;

		// ブロック数 * ブロックの大きさ / 中央に寄せるため半分に割る + ブロックの半分だけずらす
		public const float START_POS_X = NUM_WIDTH  * BLOCK_SIZE / -2.0f + BLOCK_SIZE_HALF;
		public const float START_POS_Y = NUM_HEIGHT * BLOCK_SIZE / -2.0f + BLOCK_SIZE_HALF;

		public const float TURN_TIME = 30.0f;

//        public static readonly UnityEngine.Color MASTER_COLOR = new UnityEngine.Color(0.0f, 255.0f, 255.0f, 1.0f);
        public static readonly UnityEngine.Color DEFAULT_COLOR = new UnityEngine.Color(90.0f, 0.0f, 190.0f, 1.0f);
//        public static readonly UnityEngine.Color GUEST_COLOR  = new UnityEngine.Color(255.0f, 0.0f, 0.0f, 1.0f);
        public static readonly UnityEngine.Color HOLD_COLOR  = new UnityEngine.Color(100.0f, 190.0f, 0.0f, 1.0f);

        public enum ObjectType{
            kPlayer = 1,
            kGoal,
            kBlock,
            kFixedBlock,
            kHillBlock,
            kHillBlockRight,
            kSpring,
            kFallBlock,

            kSpringLeft,
            kSpringRight,
            kFixedHillBlockLeft,
            kFixedHillBlockRight,
            kFixedFallBlock,
            kCharacter,
        }
	}
}