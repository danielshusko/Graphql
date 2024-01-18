using Google.Protobuf.WellKnownTypes;
using GraphQl.Domain;
using Grpc.Core;
using Location.Grpc.proto;
using Locations = Location.Grpc.proto.Locations;

namespace GraphQl.Grpc
{
    public class LocationGrpcService(LocationService locationService) : Locations.LocationsBase
    {

        public override Task<LocationMessage> GetById(IdRequestMessage request, ServerCallContext context)
        {
            var location = locationService.GetById(request.Id);
            if (location == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Not found"));
            }

            var locationMessage = ToLocationMessage(location);
            return Task.FromResult(locationMessage);
        }

        public override Task<LocationsMessage> GetLocations(Empty request, ServerCallContext context)
        {
            var locations = locationService.GetLocations();
            var locationMessages = locations.Select(ToLocationMessage).ToList();
            var locationsMessage = new LocationsMessage();
            locationsMessage.Locations.AddRange(locationMessages);
            return Task.FromResult(locationsMessage);
        }

        private static LocationMessage ToLocationMessage(Domain.Location location)
        {
            return new LocationMessage
            {
                Id = location.Id,
                Code = location.Code,
                Name = location.Name,
                Address = new AddressMessage
                {
                    Street = location.Address.Street,
                    City = location.Address.City,
                    State = location.Address.State.ToString(),
                    Zip = location.Address.ZipCode
                }
            };
        }
    }
}
