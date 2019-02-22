import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface EmployeeCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface EmployeeCreateComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class EmployeeCreateComponent extends React.Component<
  EmployeeCreateComponentProps,
  EmployeeCreateComponentState
> {
  state = {
    model: new EmployeeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as EmployeeViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:EmployeeViewModel) =>
  {  
    let mapper = new EmployeeMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Employees,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.EmployeeClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='birthDate'>BirthDate</label>
              <br />             
              {getFieldDecorator('birthDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"BirthDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='currentFlag'>CurrentFlag</label>
              <br />             
              {getFieldDecorator('currentFlag', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"CurrentFlag"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='gender'>Gender</label>
              <br />             
              {getFieldDecorator('gender', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 1, message: 'Exceeds max length of 1' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Gender"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='hireDate'>HireDate</label>
              <br />             
              {getFieldDecorator('hireDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"HireDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='jobTitle'>JobTitle</label>
              <br />             
              {getFieldDecorator('jobTitle', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"JobTitle"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='loginID'>LoginID</label>
              <br />             
              {getFieldDecorator('loginID', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 256, message: 'Exceeds max length of 256' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"LoginID"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='maritalStatu'>MaritalStatus</label>
              <br />             
              {getFieldDecorator('maritalStatu', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 1, message: 'Exceeds max length of 1' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"MaritalStatus"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='nationalIDNumber'>NationalIDNumber</label>
              <br />             
              {getFieldDecorator('nationalIDNumber', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 15, message: 'Exceeds max length of 15' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"NationalIDNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='organizationLevel'>OrganizationLevel</label>
              <br />             
              {getFieldDecorator('organizationLevel', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"OrganizationLevel"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='rowguid'>rowguid</label>
              <br />             
              {getFieldDecorator('rowguid', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"rowguid"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='salariedFlag'>SalariedFlag</label>
              <br />             
              {getFieldDecorator('salariedFlag', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"SalariedFlag"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='sickLeaveHour'>SickLeaveHours</label>
              <br />             
              {getFieldDecorator('sickLeaveHour', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"SickLeaveHours"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='vacationHour'>VacationHours</label>
              <br />             
              {getFieldDecorator('vacationHour', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"VacationHours"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedEmployeeCreateComponent = Form.create({ name: 'Employee Create' })(EmployeeCreateComponent);

/*<Codenesium>
    <Hash>8361cce526a3d26f8d0b4f4af4a0a798</Hash>
</Codenesium>*/