using MarsHoverApp.Extensions;

namespace MarsHoverApp
{
    public class Hover : IHover
    {
        private static int Id = 0;
        public int HoverId { get; internal set; }
        public int XAxisPosition { get; internal set; }
        public int YAxisPosition { get; internal set; }
        public Alignment Align { get; internal set; }

        public Hover()
        {
            XAxisPosition = 0;
            YAxisPosition = 0;
            Align = Alignment.N;
            HoverId = Id++;
        }
        public Hover(int startXAxis, int startYAxis, Alignment startAlign)
        {
            XAxisPosition = startXAxis;
            YAxisPosition = startYAxis;
            Align = startAlign;
            HoverId = Id++;
        }
        public void Move(string movementOrder, Field field)
        {
            try
            {
                (Alignment startAlign, int startX, int startY) = (Align, XAxisPosition, YAxisPosition);
                foreach (char move in movementOrder)
                {
                    var nextMove = (Movement)Enum.ToObject(typeof(Movement), move);
                    switch (nextMove)
                    {
                        case (Movement.Left):
                            this.Align = this.Align == Alignment.E ? Alignment.N : Align + 1;
                            break;
                        case (Movement.Right):
                            this.Align = this.Align == Alignment.N ? Alignment.E : Align - 1;
                            break;
                        case (Movement.Move):
                            //Assume that the square directly North from (x, y) is (x, y+1)
                            switch (Align)
                            {
                                case (Alignment.N):
                                    this.YAxisPosition = this.YAxisPosition + 1 <= field.HorizontalSize ? this.YAxisPosition + 1 : this.YAxisPosition;
                                    break;
                                case (Alignment.S):
                                    this.YAxisPosition = this.YAxisPosition - 1 >= 0 ? this.YAxisPosition - 1 : this.YAxisPosition;
                                    break;
                                case (Alignment.W):
                                    this.XAxisPosition = this.XAxisPosition - 1 >= 0 ? this.XAxisPosition -1 : this.XAxisPosition;
                                    break;
                                case (Alignment.E):
                                    this.XAxisPosition = this.XAxisPosition + 1 <= field.VerticalSize ? this.XAxisPosition + 1 : this.XAxisPosition;
                                    break;
                            }
                            var clashId = this.CheckClashToOtherHoverIn(field);
                            if (clashId != -1)
                            {
                                this.Align = startAlign;
                                this.XAxisPosition = startX;
                                this.YAxisPosition = startY;
                                throw new ClashException(clashId, this.HoverId);
                            }
                            break;

                    }
                }
            }
            catch (ClashException ce)
            {
                Console.WriteLine(ce.Message);
            }
        }
    }
}
