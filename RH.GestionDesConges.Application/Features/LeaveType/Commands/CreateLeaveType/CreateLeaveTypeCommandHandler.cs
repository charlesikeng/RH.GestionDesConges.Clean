using AutoMapper;
using MediatR;
using RH.GestionDesConges.Application.Contracts.Persistence;
using RH.GestionDesConges.Application.Exceptions;

namespace RH.GestionDesConges.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, Guid>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
		{
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<Guid> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//Validate incoming data
			var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any())
				throw new BadRequestException("Invalid  Leavetype", validationResult);

			//convert to domain entity object
			var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

			//add to database
			await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

			// return record id
			return leaveTypeToCreate.Id;
		}
	}
}
