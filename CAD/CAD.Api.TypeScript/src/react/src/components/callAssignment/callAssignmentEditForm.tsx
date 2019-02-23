import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallAssignmentMapper from './callAssignmentMapper';
import CallAssignmentViewModel from './callAssignmentViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CallAssignmentEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CallAssignmentEditComponentState {
  model?: CallAssignmentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CallAssignmentEditComponent extends React.Component<
  CallAssignmentEditComponentProps,
  CallAssignmentEditComponentState
> {
  state = {
    model: new CallAssignmentViewModel(),
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
          ApiRoutes.CallAssignments +
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
          let response = resp.data as Api.CallAssignmentClientResponseModel;

          console.log(response);

          let mapper = new CallAssignmentMapper();

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
        let model = values as CallAssignmentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CallAssignmentViewModel) =>
  {  
    let mapper = new CallAssignmentMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.CallAssignments + '/' + this.state.model!.id,
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
            Api.CallAssignmentClientRequestModel
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
              <label htmlFor='callId'>callId</label>
              <br />             
              {getFieldDecorator('callId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"callId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='unitId'>unitId</label>
              <br />             
              {getFieldDecorator('unitId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"unitId"} /> )}
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

export const WrappedCallAssignmentEditComponent = Form.create({ name: 'CallAssignment Edit' })(CallAssignmentEditComponent);

/*<Codenesium>
    <Hash>e9795936731e168811d3dabe8102b74d</Hash>
</Codenesium>*/