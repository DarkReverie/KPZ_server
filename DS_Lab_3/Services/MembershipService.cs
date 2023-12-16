using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;

namespace DS_Lab_3.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly GymDsCopyContext _context;

        public MembershipService(GymDsCopyContext context)
        {
            _context = context;
        }

        public Membership CreateMembership(Membership membership)
        {
            _context.Memberships.Add(membership);
            _context.SaveChanges();
            return membership;
        }

        public Membership GetMembershipById(int membershipId)
        {
            return _context.Memberships.Find(membershipId);
        }

        public Membership UpdateMembership(int membershipId, Membership updatedMembership)
        {
            var existingMembership = _context.Memberships.Find(membershipId);

            if (existingMembership != null)
            {
                existingMembership.StartDate = updatedMembership.StartDate;
                existingMembership.EndDate = updatedMembership.EndDate;
                existingMembership.MemberEmail = updatedMembership.MemberEmail;
                existingMembership.MemberPhone = updatedMembership.MemberPhone;
                existingMembership.Name = updatedMembership.Name;
                existingMembership.Surname = updatedMembership.Surname;
                // Update other properties as needed

                _context.SaveChanges();
            }

            return existingMembership;
        }

        public void DeleteMembership(int membershipId)
        {
            var membershipToDelete = _context.Memberships.Find(membershipId);

            if (membershipToDelete != null)
            {
                _context.Memberships.Remove(membershipToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return _context.Memberships;
        }
    }
}
