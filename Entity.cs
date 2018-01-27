namespace LearnerAgent
{
    public class Entity
    {
        protected float PosX;
        protected float PosY;

        public Entity(float posX, float posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public virtual void Draw()
        {
            
        }
    }
}