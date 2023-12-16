using DS_Lab_3.Models;

namespace DS_Lab_3.Interfaces;

public interface IMembershipService
{
    Membership CreateMembership(Membership membership);

    // Get a membership by its ID
    Membership GetMembershipById(int membershipId);

    // Update an existing membership
    Membership UpdateMembership(int membershipId, Membership updatedMembership);

    // Delete a membership by its ID
    void DeleteMembership(int membershipId);

    // Get a list of all memberships
    IEnumerable<Membership> GetAllMemberships();
}