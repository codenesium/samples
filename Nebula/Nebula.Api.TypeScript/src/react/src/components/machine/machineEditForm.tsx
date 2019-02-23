import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MachineMapper from './machineMapper';
import MachineViewModel from './machineViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface MachineEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface MachineEditComponentState {
  model?: MachineViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class MachineEditComponent extends React.Component<
  MachineEditComponentProps,
  MachineEditComponentState
> {
  state = {
    model: new MachineViewModel(),
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
          ApiRoutes.Machines +
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
          let response = resp.data as Api.MachineClientResponseModel;

          console.log(response);

          let mapper = new MachineMapper();

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
        let model = values as MachineViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:MachineViewModel) =>
  {  
    let mapper = new MachineMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Machines + '/' + this.state.model!.id,
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
            Api.MachineClientRequestModel
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
              <label htmlFor='description'>Description</label>
              <br />             
              {getFieldDecorator('description', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Description"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='jwtKey'>JwtKey</label>
              <br />             
              {getFieldDecorator('jwtKey', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"JwtKey"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastIpAddress'>LastIpAddress</label>
              <br />             
              {getFieldDecorator('lastIpAddress', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"LastIpAddress"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='machineGuid'>MachineGuid</label>
              <br />             
              {getFieldDecorator('machineGuid', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"MachineGuid"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>Name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Name"} /> )}
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

export const WrappedMachineEditComponent = Form.create({ name: 'Machine Edit' })(MachineEditComponent);

/*<Codenesium>
    <Hash>3b39f1379572912382470f65fdf7c95f</Hash>
</Codenesium>*/