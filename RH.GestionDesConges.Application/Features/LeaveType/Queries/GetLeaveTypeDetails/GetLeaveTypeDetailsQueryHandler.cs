﻿using AutoMapper;
using MediatR;
using RH.GestionDesConges.Application.Contracts.Persistence;
using RH.GestionDesConges.Application.Exceptions;

namespace RH.GestionDesConges.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
	public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery,
		LeaveTypeDetailDto>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
		{
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
		{
			// Query the database
			var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

			//verify that record exists
			if (leaveType == null)
				throw new NotFoundException(nameof(LeaveType), request.Id);

			// convert data object to DTO object
			var data = _mapper.Map<LeaveTypeDetailDto>(leaveType);

			// return DTO Object
			return data;
		}
	}
}
