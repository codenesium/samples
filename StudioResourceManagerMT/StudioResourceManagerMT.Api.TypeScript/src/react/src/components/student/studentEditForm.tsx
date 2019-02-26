import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudentMapper from './studentMapper';
import StudentViewModel from './studentViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
interface StudentEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface StudentEditComponentState {
  model?: StudentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class StudentEditComponent extends React.Component<
  StudentEditComponentProps,
  StudentEditComponentState
> {
  state = {
    model: new StudentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Students +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.StudentClientResponseModel;

          console.log(response);

          let mapper = new StudentMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as StudentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:StudentViewModel) =>
  {  
    let mapper = new StudentMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Students + '/' + this.state.model!.id,
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
            Api.StudentClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		  let errorResponse = error.response.data as ActionResponse; 
		  if(error.response.data)
          {
			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
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
              <label htmlFor='birthday'>birthday</label>
              <br />             
              {getFieldDecorator('birthday', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"birthday"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='email'>email</label>
              <br />             
              {getFieldDecorator('email', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"email"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='emailRemindersEnabled'>emailRemindersEnabled</label>
              <br />             
              {getFieldDecorator('emailRemindersEnabled', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"emailRemindersEnabled"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='familyId'>familyId</label>
              <br />             
              {getFieldDecorator('familyId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"familyId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='firstName'>firstName</label>
              <br />             
              {getFieldDecorator('firstName', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"firstName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='isAdult'>isAdult</label>
              <br />             
              {getFieldDecorator('isAdult', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"isAdult"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastName'>lastName</label>
              <br />             
              {getFieldDecorator('lastName', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"lastName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='phone'>phone</label>
              <br />             
              {getFieldDecorator('phone', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"phone"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='smsRemindersEnabled'>smsRemindersEnabled</label>
              <br />             
              {getFieldDecorator('smsRemindersEnabled', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"smsRemindersEnabled"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userId'>userId</label>
              <br />             
              {getFieldDecorator('userId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"userId"} /> )}
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

export const WrappedStudentEditComponent = Form.create({ name: 'Student Edit' })(StudentEditComponent);

/*<Codenesium>
    <Hash>02fa993cc167bf4049f05d30fc97d565</Hash>
</Codenesium>*/