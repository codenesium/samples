import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import TweetMapper from '../tweet/tweetMapper';
import TweetViewModel from '../tweet/tweetViewModel';
import {
  Spin,
  Alert,
  Select
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TweetSelectComponentProps {
  getFieldDecorator: any;
  apiRoute:string;
  selectedValue:number;
  propertyName:string;
  required:boolean;
}

interface TweetSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<TweetViewModel>;
}

export class  TweetSelectComponent extends React.Component<
TweetSelectComponentProps,
TweetSelectComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

  componentDidMount() {
   
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.TweetClientResponseModel>;

          console.log(response);

          let mapper = new TweetMapper();
          
          let devices:Array<TweetViewModel> = [];

          response.forEach(x =>
          {
              devices.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: devices,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    

    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
    else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type='error' />;
    }
	  else if (this.state.loaded) {
      return (
        <div>
        {
          this.props.getFieldDecorator(this.props.propertyName, {
          initialValue: this.props.selectedValue,
          rules: [{ required: this.props.required, message: 'Required' }],
        })(
          <Select>
          {
            this.state.filteredRecords.map((x:TweetViewModel) =>
            {
                return <Select.Option value={x.tweetId}>{x.toDisplay()}</Select.Option>;
            })
          }
          </Select>
        )
      }
      </div>
    );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>24f0b8fb54062012d7ee4ae560f97b66</Hash>
</Codenesium>*/