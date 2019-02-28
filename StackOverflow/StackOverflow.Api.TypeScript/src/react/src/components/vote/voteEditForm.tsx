import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VoteMapper from './voteMapper';
import VoteViewModel from './voteViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
interface VoteEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface VoteEditComponentState {
  model?: VoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class VoteEditComponent extends React.Component<
  VoteEditComponentProps,
  VoteEditComponentState
> {
  state = {
    model: new VoteViewModel(),
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
          ApiRoutes.Votes +
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
          let response = resp.data as Api.VoteClientResponseModel;

          console.log(response);

          let mapper = new VoteMapper();

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
        let model = values as VoteViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:VoteViewModel) =>
  {  
    let mapper = new VoteMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Votes + '/' + this.state.model!.id,
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
            Api.VoteClientRequestModel
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
              <label htmlFor='bountyAmount'>BountyAmount</label>
              <br />             
              {getFieldDecorator('bountyAmount', {
              rules:[],
              
              })
              ( <Input placeholder={"BountyAmount"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='creationDate'>CreationDate</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"CreationDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='postId'>PostId</label>
              <br />             
              {getFieldDecorator('postId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"PostId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userId'>UserId</label>
              <br />             
              {getFieldDecorator('userId', {
              rules:[],
              
              })
              ( <Input placeholder={"UserId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='voteTypeId'>VoteTypeId</label>
              <br />             
              {getFieldDecorator('voteTypeId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"VoteTypeId"} /> )}
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

export const WrappedVoteEditComponent = Form.create({ name: 'Vote Edit' })(VoteEditComponent);

/*<Codenesium>
    <Hash>0e65378f44bc289886adf1387b20ff95</Hash>
</Codenesium>*/