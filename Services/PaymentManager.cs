using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class PaymentManager : IPaymentService
    {
        private readonly IRepositoryManager _manager;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public PaymentManager(IRepositoryManager manager, IMapper mapper, ICustomerService customerService)
        {
            _manager = manager;
            _mapper = mapper;
            _customerService = customerService;
        }

        public PaymentDto AddPayment(PaymentDtoForManipulation paymentDto)
        {
            _customerService
            .GetCustomerById(paymentDto.CustomerId, false);

            var entity = _mapper.Map<Payment>(paymentDto);
            _manager.Payment.CreateOnePayment(entity);
            _manager.Save();

            return _mapper.Map<PaymentDto>(entity);
        }

        public void DeletePayment(int id, bool trackChanges)
        {
            var entity = GetOnePaymentAndCheckExists(id, trackChanges);
            
            _manager.Payment.DeleteOnePayment(entity);
            _manager.Save();
        }

        public IEnumerable<Payment> GetAllPayments(bool trackChanges)
        {
            return _manager.Payment.GetAllPayments(trackChanges); 
        }

        public IEnumerable<Payment> GetAllPaymentsWithCustomers(bool trackChanges)
        {
            return _manager
                .Payment
                .GetAllPaymentsWithCustomers(trackChanges);
        }

        public PaymentDto GetPaymentById(int id, bool trackChanges)
        {
            var payment = GetOnePaymentAndCheckExists(id, trackChanges);

            return _mapper.Map<PaymentDto>(payment);
        }

        public void UpdatePayment(int id, PaymentDtoForManipulation paymentDto, bool trackChanges)
        {
            var entity = GetOnePaymentAndCheckExists(id, false);

            _customerService
            .GetCustomerById(paymentDto.CustomerId, false);

            entity = _mapper.Map<Payment>(paymentDto);
            
            _manager.Payment.UpdateOnePayment(entity);
            _manager.Save();
        }

        private Payment GetOnePaymentAndCheckExists(int id, bool trackChanges)
        {
            var entity = _manager.Payment.GetOnePaymentById(id, trackChanges);

            if(entity is null)
                throw new PaymentNotFoundException(id);

            return entity;
        }
    }
}
