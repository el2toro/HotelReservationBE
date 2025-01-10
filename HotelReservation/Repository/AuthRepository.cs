using HotelReservation.Contexts;
using HotelReservation.DTOs;

namespace HotelReservation.Repository;

public interface IAuthRepository
{
    public UserDto Login(UserDto user);
}

public class AuthRepository : IAuthRepository
{
    private readonly HotelReservationContext _context;
    public AuthRepository(HotelReservationContext context)
    {
           _context = context;
    }
    public UserDto Login(UserDto user)
    {
		try
		{
			var existingUser = _context.Users.Single(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {
                return new UserDto
                {
                    Username = existingUser.Username,
                    Password = existingUser.Password
                };
            }

            return new UserDto();
		}
		catch (Exception)
		{
			throw;
		}
    }
}
