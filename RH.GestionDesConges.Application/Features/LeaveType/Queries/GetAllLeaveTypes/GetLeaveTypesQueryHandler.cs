using AutoMapper;
using MediatR;
using RH.GestionDesConges.Application.Contracts.Logging;
using RH.GestionDesConges.Application.Contracts.Persistence;

namespace RH.GestionDesConges.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

		public GetLeaveTypesQueryHandler(IMapper mapper,
			ILeaveTypeRepository leaveTypeRepository,
			IAppLogger<GetLeaveTypesQueryHandler> logger)
		{
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
			_logger = logger;
		}

		public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
		{
			// Query the database
			var leaveTypes = await _leaveTypeRepository.GetAsync();

			// convert data objects to DTO objects
			var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

			// return list of DTO Object
			return data;
		}
	}
}
