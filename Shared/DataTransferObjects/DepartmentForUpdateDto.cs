﻿namespace Shared.DataTransferObjects
{
    public record DepartmentForUpdateDto(string DepartmentName, ICollection<ProductForCreationDto> Products);
}
