import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherMapper from './teacherMapper';
import TeacherViewModel from './teacherViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface TeacherEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TeacherEditComponentState {
  model?: TeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class TeacherEditComponent extends React.Component<
  TeacherEditComponentProps,
  TeacherEditComponentState
> {
  state = {
    model: new TeacherViewModel(),
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
          ApiRoutes.Teachers +
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
          let response = resp.data as Api.TeacherClientResponseModel;

          console.log(response);

          let mapper = new TeacherMapper();

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
        let model = values as TeacherViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:TeacherViewModel) =>
  {  
    let mapper = new TeacherMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Teachers + '/' + this.state.model!.id,
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
            Api.TeacherClientRequestModel
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
      return <LoadingForm />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='birthday'>birthday</label>
              <br />             
{getFieldDecorator('birthday', {
              rules:[],
              })
              ( <DatePicker placeholder={"birthday"} id={"birthday"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='email'>email</label>
              <br />             
{getFieldDecorator('email', {
              rules:[],
              })
              ( <Input placeholder={"email"} id={"email"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='firstName'>First Name</label>
              <br />             
{getFieldDecorator('firstName', {
              rules:[],
              })
              ( <Input placeholder={"First Name"} id={"firstName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastName'>Last Name</label>
              <br />             
{getFieldDecorator('lastName', {
              rules:[],
              })
              ( <Input placeholder={"Last Name"} id={"lastName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='phone'>phone</label>
              <br />             
{getFieldDecorator('phone', {
              rules:[],
              })
              ( <InputNumber placeholder={"phone"} id={"phone"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userId'>userId</label>
              <br />             
{getFieldDecorator('userId', {
              rules:[],
              })
              ( <InputNumber placeholder={"userId"} id={"userId"} /> )}
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

export const WrappedTeacherEditComponent = Form.create({ name: 'Teacher Edit' })(TeacherEditComponent);

/*<Codenesium>
    <Hash>327c0c447d0f6d94c30c0600f6bd0af1</Hash>
</Codenesium>*/