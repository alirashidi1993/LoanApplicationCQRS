using EventStore.Client;

namespace LoanApplications.Projections.Sql.Framework
{
    public class FakeCursor : ICursor
    {
        public Position CurrentPosition()
        {
            return Position.Start;
        }

        public void MoveTo(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
